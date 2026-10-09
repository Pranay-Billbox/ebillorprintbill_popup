using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace PrintPopup
{
    public partial class Form1 : Form
    {

        private bool isSubmit = false;
        public Form1()
        {
            InitializeComponent();
            
            SetupEvents();

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = true;
           

            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }



        private void EnsureDefaultFile()
        {
            string defaultPath = @"C:\BillBox\common\configs\default_data.json";

            JObject template = new JObject
            {
                ["name"] = "",
                ["mobile"] = "customer_no",
                ["paper"] = false,
                ["under18"] = false,
                ["gender"] = "",
                ["reports"] = false,
                ["is_submit"] = false
            };

            try
            {
                // ✅ create if missing
                if (!File.Exists(defaultPath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(defaultPath));
                    File.WriteAllText(defaultPath, template.ToString(Newtonsoft.Json.Formatting.Indented));
                    return;
                }
                else
                {
                    File.WriteAllText(defaultPath, template.ToString(Newtonsoft.Json.Formatting.Indented));
                }

                // ✅ read existing
                JObject current = JObject.Parse(File.ReadAllText(defaultPath));

                // ✅ validation (your switch logic stays same)
                foreach (var prop in template.Properties())
                {
                    string key = prop.Name;
                    JToken def = prop.Value;
                    JToken cur = current[key];

                    if (cur == null)
                    {
                        current[key] = def;
                        continue;
                    }

                    switch (key)
                    {
                        case "name":
                            if (cur.Type != JTokenType.String)
                                current[key] = "";
                            break;

                        case "mobile":
                            string mobile = cur.ToString();
                            if (mobile != "customer_no" &&
                                (mobile.Length != 10 || !mobile.All(char.IsDigit)))
                            {
                                current[key] = "customer_no";
                            }
                            break;

                        case "paper":
                        case "under18":
                        case "reports":
                        case "is_submit":
                            if (cur.Type != JTokenType.Boolean)
                                current[key] = def;
                            break;

                        case "gender":
                            string g = cur.ToString().ToLower();
                            if (g != "" && g != "male" && g != "female")
                                current[key] = "";
                            break;
                    }
                }

                // ✅ ✅ ALWAYS rewrite (NO if condition)
                File.WriteAllText(defaultPath, current.ToString(Newtonsoft.Json.Formatting.Indented));
            }
            catch
            {
                // ✅ fallback → reset completely
                File.WriteAllText(defaultPath, template.ToString(Newtonsoft.Json.Formatting.Indented));
            }
        }


        private void WritePaperOnlyData(bool isPaper)
        {
            string defaultPath = @"C:\BillBox\common\configs\default_data.json";
            string dataPath = @"C:\BillBox\common\configs\data.json";

            EnsureDefaultFile();

            // ✅ Read default
            JObject data = JObject.Parse(File.ReadAllText(defaultPath));

            // ✅ Modify only paper
            data["paper"] = isPaper;
            data["is_submit"] = true;

            // ✅ Write to correct file
            File.WriteAllText(dataPath, data.ToString(Newtonsoft.Json.Formatting.Indented));
        }



        private void SetupEvents()
        {
            // ✅ Focus underline effect
            checkBox1.GotFocus += (s, e) => underlinePanel.Visible = true;
            checkBox1.LostFocus += (s, e) => underlinePanel.Visible = false;

            // ✅ Keyboard navigation
            checkBox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnEbill.Focus();
                }
            };

            btnEbill.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnEbill.PerformClick();
                }
                else if (e.KeyCode == Keys.Up)
                {
                    e.SuppressKeyPress = true;
                    checkBox1.Focus();
                }
            };

            // ✅ Button click logic
            btnEbill.Click += (s, e) =>
            {
                bool isPaper = checkBox1.Checked;

                isSubmit = true;   // ✅ mark submit

                WritePaperOnlyData(isPaper);

                this.Close();
            };

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (!isSubmit)   // ✅ user clicked X
                {
                    string defaultPath = @"C:\BillBox\common\configs\default_data.json";
                    string dataPath = @"C:\BillBox\common\configs\data.json";

                    EnsureDefaultFile();

                    JObject data = JObject.Parse(File.ReadAllText(defaultPath));

                    data["is_submit"] = false;

                    File.WriteAllText(dataPath, data.ToString(Newtonsoft.Json.Formatting.Indented));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }

            base.OnFormClosing(e);
        }

        // ✅ Block ESC + Close
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
    }
}
