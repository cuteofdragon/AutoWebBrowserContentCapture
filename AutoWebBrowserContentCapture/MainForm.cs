using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.IO;

using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using mshtml;

namespace AutoWebBrowserContentCapture
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            webBrowser1.ScriptErrorsSuppressed = true;

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            // http://www.codeproject.com/Articles/31163/Suppressing-Hosted-WebBrowser-Control-Dialogs

        }

        private void urlTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate();
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Navigate();
        }

        void Navigate()
        {
            try
            {
                Encoding encode = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urlTextBox.Text);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome Safari/537.36";
                request.KeepAlive = false;
                IAsyncResult iar1 = request.BeginGetResponse(null, null);
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(iar1))
                    {
                        if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                        {
                            string temp = Path.GetTempFileName();
                            BinaryReader br = new BinaryReader(response.GetResponseStream());
                            byte[] buffer = new byte[4096];
                            MemoryStream ms = new MemoryStream();
                            int n = 0;
                            do
                            {
                                n = br.Read(buffer, 0, buffer.Length);
                                ms.Write(buffer, 0, n);
                            } while (n > 0);
                            br.Dispose();
                            buffer = ms.ToArray();
                            ms.Close();

                            String html = Encoding.ASCII.GetString(buffer);
                            try
                            {
                                Match match = Regex.Match(html, @"<meta[^>]*charset[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                if (match.Success)
                                {
                                    string[] ss = match.Value.Split(new string[] { "charset=" }, StringSplitOptions.RemoveEmptyEntries);
                                    string charset = ss[ss.Length - 1].Split(new char[] { '"', ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                                    encode = Encoding.GetEncoding(charset);
                                }
                            }
                            catch
                            {
                            }


                            html = encode.GetString(buffer);
                            // http://bytes.com/topic/c-sharp/answers/228303-using-mshtml-parsing-html-files-c
                            try
                            {
                                // http://stackoverflow.com/questions/2505957/using-regex-to-remove-script-tags
                                // http://go4answers.webhost4life.com/Example/regex-match-body-tag-help-111595.aspx
                                Match match = Regex.Match(html, @"<body[^>]*>(.*?)</body>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                if (match.Success)
                                {
                                    html = match.Value;
                                    HTMLDocument doc = new HTMLDocument();
                                    IHTMLDocument2 doc2 = (IHTMLDocument2)doc;
                                    doc2.write(new object[] { html });

                                    IHTMLDOMNode dom = (IHTMLDOMNode)doc2;

                                    IHTMLElementCollection scripts = ((IHTMLElement2)doc2.body).getElementsByTagName("script");                                    
                                    foreach (IHTMLElement script in scripts)
                                    {
                                        // http://stackoverflow.com/questions/554233/removing-htmlelement-objects-programmatically-using-c-sharp
                                        IHTMLDOMNode node = script as IHTMLDOMNode;
                                        node.parentNode.removeChild(node);
                                    }

                                    IHTMLElementCollection imgs = ((IHTMLElement2)doc2.body).getElementsByTagName("img");                                    
                                    foreach (IHTMLElement img in imgs)
                                    {                                        
                                        IHTMLDOMNode node = img as IHTMLDOMNode;
                                        IHTMLElement el = img as IHTMLElement;
                                        string src = el.getAttribute("src");                                        
                                        if (removeImageCheckBox.Checked || !src.StartsWith("http"))
                                        {
                                            node.parentNode.removeChild(node);
                                        }
                                    }

                                    if (removeHyperlinkCheckBox.Checked)
                                    {
                                        IHTMLElementCollection @as = ((IHTMLElement2)doc2.body).getElementsByTagName("a");
                                        foreach (IHTMLElement a in @as)
                                        {
                                            IHTMLDOMNode node = a as IHTMLDOMNode;
                                            node.parentNode.removeChild(node);
                                        }
                                    }

                                    html = doc2.body.innerHTML;
                                }
                            }
                            catch
                            {
                            }
                            html = String.Format("<html><body>{0}</body></html>", html);
                            File.WriteAllText(temp, html, encode);

                            // http://stackoverflow.com/questions/5362591/how-to-display-the-string-html-contents-into-webbrowser-control
                            //webBrowser1.DocumentText = html;

                            // http://www.c-sharpcorner.com/uploadfile/d2dcfc/convert-html-to-word-then-word-to-pdf-with-C-Sharp/
                            object missing = System.Reflection.Missing.Value;
                            Word.Application word = new Word.Application();
                            // http://bytes.com/topic/c-sharp/answers/243445-word-interop-quickly-inserting-html-files-into-word-doc
                            word.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;                            
                            Word.Document document = word.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                            // http://www.cprogramdevelop.com/3434569/
                            document.ActiveWindow.View.Type = Word.WdViewType.wdWebView;
                            //word.Options.Pagination = false;
                            //word.ScreenUpdating = false;
                            word.Visible = true;

                            // http://charliedigital.com/2010/09/29/inserting-html-into-word-documents/
                            // http://msdn.microsoft.com/en-us/library/bb217015%28office.12%29.aspx
                            // http://msdn.microsoft.com/en-us/library/office/ff191763(v=office.15).aspx
                            document.Range().InsertFile(temp, missing, false, false, false);
                            //Clipboard.SetText(html, TextDataFormat.Text);                            
                            //word.Selection.PasteSpecial(missing, missing, missing, missing, Word.WdPasteDataType.wdPasteHTML, missing, missing);
                            
                            word.Activate();

                        }
                        else
                        {
                        }
                    }
                }
                catch (WebException e4)
                {
                    throw e4;
                }
                catch (Exception e2)
                {
                    throw e2;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {

        }
    }
}
