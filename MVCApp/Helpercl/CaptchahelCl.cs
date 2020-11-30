using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCApp.Helpercl
{
    public class CaptchahelCl
    {
      
        public dynamic check_s_captch()
        {
            dynamic objcap = new ExpandoObject();
            MemoryStream oMemoryStream = new MemoryStream();
            Bitmap objBitmap = new Bitmap(130, 80);
            try
            {
                Graphics objGraphics = Graphics.FromImage(objBitmap);
                objGraphics.Clear(Color.White);
                Random objRandom = new Random();
                objGraphics.DrawLine(Pens.Black, objRandom.Next(0, 50), objRandom.Next(10, 30), objRandom.Next(0, 200), objRandom.Next(0, 50));
                objGraphics.DrawRectangle(Pens.Blue, objRandom.Next(0, 20), objRandom.Next(0, 20), objRandom.Next(50, 80), objRandom.Next(0, 20));
                objGraphics.DrawLine(Pens.Blue, objRandom.Next(0, 20), objRandom.Next(10, 50), objRandom.Next(100, 200), objRandom.Next(0, 80));
                Brush objBrush = default(Brush);
                HatchStyle[] aHatchStyles = new HatchStyle[]
                {
                     HatchStyle.LargeGrid, HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal
                };
                RectangleF oRectangleF = new RectangleF(0, 0, 300, 300);
                objBrush = new HatchBrush(aHatchStyles[objRandom.Next(aHatchStyles.Length - 3)], Color.FromArgb((objRandom.Next(100, 255)), (objRandom.Next(100, 255)), (objRandom.Next(100, 255))), Color.White);
                objGraphics.FillRectangle(objBrush, oRectangleF);
                string captchaText = string.Format("{0:X}", objRandom.Next(1000000, 9999999));
                Font objFont = new Font("Courier New", 16, FontStyle.Bold);
                objGraphics.DrawString(captchaText, objFont, Brushes.Black, 15, 30);
                objGraphics.Flush();
                objGraphics.Dispose();
                objBitmap.Save(oMemoryStream, ImageFormat.Gif);
                byte[] oBytes = oMemoryStream.GetBuffer();
                string uniqueid = DateTime.Now.Ticks.ToString();
                CaptchaCl _Capli = new CaptchaCl();
                _Capli.Code = captchaText;
                _Capli.CId = AesEncDechelCl.EncryptText(DateTime.Now.Ticks.ToString(), AesencPasswordCl.CaptchEncdecPwd);
                _Capli.IpAddress = IpAddresshelCl.Ipaddress();
                _Capli.SysAddress = IpAddresshelCl.ClientSystemname();
                //_Capli.Brow = _Iphel.Browser();
                //_Capli.BrowVer = _Iphel.BrowserVer();
                bool captchgen = true;
                if (captchgen == true)
                {
                    string base64String = Convert.ToBase64String(oBytes, 0, oBytes.Length);
                    //retrn.idval = Encrypt(ids, "suresh");
                    //retrn.requestip = getipuser();
                    //retrn.status = "Success";
                    //retrn.imgurl = base64String;
                }
                else
                {
                    //retrn.idval = "";
                    //retrn.status = "fail";
                    //retrn.imgurl = "";
                }
            }
            catch (Exception e)
            {
                objcap.Code = 104;
                objcap.Reason = e.Message.ToString();
            }
            finally
            {
                objBitmap.Dispose();
                oMemoryStream.Close();
            }
            return objcap;
        }
    }
}