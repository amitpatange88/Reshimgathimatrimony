using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiMatrimony
{
    public sealed class Reshimgathi
    {
        private static Reshimgathi instance = null;
        private static readonly object obj = new object();

        public static Reshimgathi Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            return new Reshimgathi();
                    }
                }

                return instance;
            }
        }

        private Reshimgathi()
        {
        }

        public string GenerateReshimgathiId()
        {
            bool SearchShouldGoOn = true;
            string reshimgathiId = string.Empty;
            while(SearchShouldGoOn)
            {

                using (ReshimgathiMatrimonyEntities db = new ReshimgathiMatrimonyEntities())
                {
                    reshimgathiId = GetRandomReshimGathiId();
                    var IsDuplicateId = db.RegistrationPhase1.Where(x => x.ReshimgathiId == reshimgathiId).FirstOrDefault();

                    if(IsDuplicateId == null)
                    {
                        SearchShouldGoOn = false;
                        return reshimgathiId;
                    }
                }
            }

            return string.Empty;
        }

        public string GetRandomReshimGathiId()
        {
            Random generator = new Random();
            int uniqueId = generator.Next(100000, 999999);
            string reshimgathiId = "RM-" + uniqueId.ToString();

            return reshimgathiId;
        }
    }
}