namespace BelzonaMobile
{
	public static class Constants
	{
        // URL of REST service
        //public static string RestUrl = "http://http://development.belzona.com/belzona-app/us/app-manifest-ind-app-us.json";
        // Credentials that are hard coded into the REST service
        //public static string Username = "Xamarin";
        //public static string Password = "Pa$$w0rd";

        public static bool UseMockDataStore = false;
        //Belzona Products ;
        /*
         * Language: uk: English - UK, us:English - USA, el: Español - América Latina, es: Español - Europa, fr: Français, de: Deutsch, ru:Русский, pt: Português, cn:中文 (Chinise)
         * 
        API manifest-products
        */
        public static string BackendUrl = @"http://development.belzona.com/belzona-app/us/app-manifest-products-us.json";

        // API manifest-ind
        public static string BackendUrlIInd = @"http://development.belzona.com/belzona-app/us/app-manifest-ind-app-us.json";
        // Fro =industry products
        public static string BackendUrlOthers = @"http://development.belzona.com/belzona-app/us/app-manifest-ind-app-us.json";

        /* 1. file_path, formulation_number, name, series_id, type_id, short_description, long_description
         * 2. video_id, code, title, short_description, long_description, VideoName, DataLink, Size, YoutubeLink, VideoDescription
         * 3. video_id, code, industry, short_description, long_description, VideoName, DataLink, Size, YoutubeLink, VideoDescription
         * 
         * 
         */
	}
}
