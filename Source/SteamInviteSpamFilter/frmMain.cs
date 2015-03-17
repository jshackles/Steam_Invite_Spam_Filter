using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using HtmlAgilityPack;

namespace SteamInviteSpamFilter
{
    public partial class frmMain : Form
    {
        public Boolean cookieReady = false;
        public int invitesIgnored = 0;

        public CookieContainer generateCookies()
        {
            CookieContainer cookies = new CookieContainer();
            Uri target = new Uri("http://steamcommunity.com");
            cookies.Add(new Cookie("sessionid", Properties.Settings.Default.sessionid) { Domain = target.Host });
            cookies.Add(new Cookie("steamLogin", Properties.Settings.Default.steamLogin) { Domain = target.Host });
            cookies.Add(new Cookie("steamparental", Properties.Settings.Default.steamparental) { Domain = target.Host });
            return cookies;
        }

        public async Task<string> GetHttpAsync(String url, CookieContainer cookies)
        {
            String content = "";
            try
            {
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(url);
                r.Method = "GET";
                r.CookieContainer = cookies;
                HttpWebResponse res = (HttpWebResponse)await r.GetResponseAsync();
                if (res != null)
                {
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        Stream stream = res.GetResponseStream();
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            content = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return content;
        }

        public async Task IgnoreInvite(string user_id)
        {
            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer = generateCookies();
            using (HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (HttpClient client = new HttpClient(handler))
            {                
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Host = "steamcommunity.com";
                client.DefaultRequestHeaders.Add("Origin", "http://steamcommunity.com");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36");
                client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                client.DefaultRequestHeaders.Add("Referer", "http://steamcommunity.com/id/" + Properties.Settings.Default.myProfileName + "/home/invites/");
                
                var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("json", "1"),
                    new KeyValuePair<string, string>("xml", "1"),
                    new KeyValuePair<string, string>("action", "approvePending"),
                    new KeyValuePair<string, string>("itype", "friend"),
                    new KeyValuePair<string, string>("perform", "ignore"),
                    new KeyValuePair<string, string>("id", user_id),
                    new KeyValuePair<string, string>("sessionID", Properties.Settings.Default.sessionid)
                });

                HttpResponseMessage response = await client.PostAsync("http://steamcommunity.com/id/" + Properties.Settings.Default.myProfileName + "/home_process", content);
                var responseString = await response.Content.ReadAsStringAsync();

                Regex regex = new Regex("success\":1");

                if (regex.IsMatch(responseString)) 
                {
                    invitesIgnored = invitesIgnored + 1;
                    tsInviteBlockedCount.Visible = true;
                    tsInviteBlockedCount.Text = "(" + invitesIgnored.ToString() + " invites ignored)";
                }
            }
        }

        public async Task GetInvites()
        {
            CookieContainer cookies = generateCookies();
            string response = await GetHttpAsync(Properties.Settings.Default.myProfileURL + "/home/invites", cookies);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(response);
            HtmlNodeCollection user_avatar = document.DocumentNode.SelectNodes("//div[contains(@class,'user_avatar')]");
            try
            {
                int Count = user_avatar.Count;
            }
            catch (Exception)
            {
                // Invalid cookie data
                cookieReady = false;
                lnkResetCookies_LinkClicked(null, null);
                return;
            }
            try
            {
                foreach (HtmlNode invite in document.DocumentNode.SelectNodes("//div[contains(@class,'invite_row')]"))
                {
                    string user_name = "";
                    string user_profile_name = "";
                    string user_profile_id = "";
                    int user_level = 0;
                    HtmlNodeCollection user_name_data = invite.SelectNodes(".//a[contains(@class, 'linkTitle')]");
                    if (user_name_data != null)
                    {
                        foreach (HtmlNode data in user_name_data)
                        {
                            if (data != null)
                            {
                                user_name = data.InnerHtml;
                                user_profile_name = data.GetAttributeValue("href", "not_found").ToString();
                                user_profile_name = user_profile_name.Replace("http://steamcommunity.com/id/", "");
                                user_profile_name = user_profile_name.Replace("http://steamcommunity.com/profiles/", "");
                            }
                        }
                    }
                    HtmlNodeCollection user_level_data = invite.SelectNodes(".//span[contains(@class, 'friendPlayerLevelNum')]");
                    if (user_level_data != null)
                    {
                        foreach (HtmlNode data in user_level_data)
                        {
                            if (data != null)
                            {
                                user_level = Convert.ToInt16(data.InnerHtml);
                            }
                        }
                    }
                    HtmlNodeCollection user_id_data = invite.SelectNodes(".//div[contains(@class, 'acceptDeclineBlock')]");
                    if (user_id_data != null)
                    {
                        foreach (HtmlNode data in user_id_data)
                        {
                            if (data != null)
                            {
                                user_profile_id = Regex.Match(data.InnerHtml, @"javascript:FriendAccept\( \'(\d.+)\', \'accept\'").Groups[1].Value;                            
                            }
                        }
                    }

                    if (radIgnoreLevel.Checked)
                    {
                        if (user_level <= numLevel.Value)
                        {
                            await IgnoreInvite(user_profile_id);
                        }
                    }

                    if (radIgnoreAll.Checked)
                    {
                        await IgnoreInvite(user_profile_id);
                    }

                }

            }
            catch (Exception)
            {

            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void lnkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBrowser frm = new frmBrowser();
            frm.ShowDialog();
        }

        private void lnkResetCookies_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Clear the settings
            Properties.Settings.Default.sessionid = "";
            Properties.Settings.Default.steamLogin = "";
            Properties.Settings.Default.myProfileURL = "";
            Properties.Settings.Default.steamparental = "";
            Properties.Settings.Default.Save();

            // Set timer intervals
            tmrCheckCookieData.Interval = 500;

            // Set cookieReady to false
            cookieReady = false;

            // Re-enable tmrReadyToGo
            tmrCheckInvites.Interval = 100;
            tmrCheckInvites.Enabled = true;
        }

        private void tmrCheckCookieData_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.sessionid != "" && Properties.Settings.Default.steamLogin != "")
            {
                lblCookieStatus.Text = "Steam Invite Spam Filter is connected to Steam";
                lblCookieStatus.ForeColor = System.Drawing.Color.Green;
                picCookieStatus.Image = Properties.Resources.imgTrue;
                lnkSignIn.Visible = false;
                lnkResetCookies.Visible = true;
                cookieReady = true;
                chkEnable.Enabled = true;                
            }
            else
            {
                lblCookieStatus.Text = "Steam Invite Spam Filter is not connected to Steam";
                lblCookieStatus.ForeColor = System.Drawing.Color.Black;
                picCookieStatus.Image = Properties.Resources.imgFalse;
                lnkSignIn.Visible = true;
                lnkResetCookies.Visible = false;
                cookieReady = false;
                chkEnable.Enabled = false;
            }
        }

        private async void tmrCheckInvites_Tick(object sender, EventArgs e)
        {
            if (cookieReady && chkEnable.Checked)
            {
                // Set the program status
                tsStatusText.Text = "Filter running";
                tsStatusText.Image = Properties.Resources.imgTrue;

                // Reset the timer interval
                tmrCheckInvites.Interval = 15000;

                // Call the GetInvites() function asynchronously
                await GetInvites();
            }
            else
            {
                tsStatusText.Text = "Filter not running";
                tsStatusText.Image = Properties.Resources.imgFalse;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.startMinimized)
            {
                startMinimizedToolStripMenuItem.Image = Properties.Resources.imgTrue;
            }
            
            if (Properties.Settings.Default.enabled)
            {
                chkEnable.Checked = true;
            }
            else
            {
                chkEnable.Checked = false;
            }
            numLevel.Value = Properties.Settings.Default.ignoreLevel;
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked) 
            {
                Properties.Settings.Default.enabled = true;
            }
            else
            {
                Properties.Settings.Default.enabled = false;
            }
            Properties.Settings.Default.Save();
            tmrCheckInvites.Interval = 100;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numLevel_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ignoreLevel = Convert.ToInt16(numLevel.Value);
            Properties.Settings.Default.Save();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout form = new frmAbout();
            form.Show();
        }

        private void startMinimizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.startMinimized)
            {
                Properties.Settings.Default.startMinimized = false;
                startMinimizedToolStripMenuItem.Image = Properties.Resources.imgFalse;
            }
            else
            {
                Properties.Settings.Default.startMinimized = true;
                startMinimizedToolStripMenuItem.Image = Properties.Resources.imgTrue;
            }
            Properties.Settings.Default.Save();            
        }
    }
}