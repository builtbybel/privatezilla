using System.Collections.Generic;

namespace Privatezilla.Setting.Bloatware
{
    public static class BloatwareList
    {
        // Our Windows 11 bloatware list
        public static IEnumerable<string> GetList()
        {
            var apps = new List<string>
            {
                "2FE3CB00.PICSART-PHOTOSTUDIO",
                "4DF9E0F8.Netflix",
                "5319275A.WhatsAppDesktop",
                "9E2F88E3.TWITTER",
                "AdobeSystemsIncorporated.AdobeLightroom",
                "AdobeSystemsIncorporated.AdobePhotoshopExpress",
                "Clipchamp.Clipchamp_yxz26nhyzhsrt",
                "CorelCorporation.PaintShopPro",
                "FACEBOOK.317180B0BB486",
                "Facebook.InstagramBeta",
                "Microsoft.549981C3F5F10",
                "Microsoft.BingNews",
                "Microsoft.BingWeather",
                "Microsoft.GamingApp",
                "Microsoft.Getstarted",
                "Microsoft.Microsoft3DViewer",
                "Microsoft.MicrosoftOfficeHub",
                "Microsoft.MicrosoftSolitaireCollection",
                "Microsoft.MicrosoftStickyNotes",
                "Microsoft.MixedReality.Portal",
                "Microsoft.Office.OneNote",
                "Microsoft.OneConnect",
                "Microsoft.People",
                "Microsoft.Print3D",
                "Microsoft.SkypeApp",
                "Microsoft.Wallet",
                "Microsoft.WindowsSoundRecorder",
                "NAVER.LINEwin8_8ptj331gd3tyt",
                "SpotifyAB.SpotifyMusic",
                "king.com.CandyCrushFriends",
                "king.com.CandyCrushSaga",
                "king.com.FarmHeroesSaga",
            };

            return apps;
        }
    }
}