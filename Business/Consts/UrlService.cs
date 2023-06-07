using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Consts
{
    public static class UrlService
    {
        public static Uri AuthApiUrl ;
        public static Uri AuthUserApiUrl;
        public static Uri AuthOperationClaimsApiUrl;
        public static Uri AuthUserOperationClaimsApiUrl;

        public static Uri MeterApiUrl;
        public static Uri MeterBrandApiUrl;
        public static Uri MeterModelApiUrl;
        public static Uri MeterReadingTimeApiUrl;

        public static Uri ReadingApiUrl ;

        public static Uri ModemApiUrl;
        public static Uri ModemBrandApiUrl;
        public static Uri ModemModelApiUrl;

        public static Uri CustomerApiUrl;

        static UrlService()
        {
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                AuthApiUrl = new Uri("http://localhost:8080/api/auth/");
                AuthUserApiUrl = new Uri("http://localhost:8080/api/users/");
                AuthOperationClaimsApiUrl=new Uri("http://localhost:8080/api/operationClaims/");
                AuthUserOperationClaimsApiUrl = new Uri("http://localhost:8080/api/userOperationClaims/");

                MeterApiUrl = new Uri("http://localhost:8090/api/meters/");
                MeterBrandApiUrl = new Uri("http://localhost:8090/api/brands/");
                MeterModelApiUrl = new Uri("http://localhost:8090/api/models/");
                MeterReadingTimeApiUrl = new Uri("http://localhost:8090/api/readingTimes/");

                ReadingApiUrl = new Uri("http://localhost:8010/api/readings/");

                ModemApiUrl = new Uri("http://localhost:8100/api/modems/");
                ModemBrandApiUrl = new Uri("http://localhost:8100/api/brands/");
                ModemModelApiUrl = new Uri("http://localhost:8100/api/models/");

                CustomerApiUrl= new Uri("http://localhost:8070/api/customers/");
            }
            else
            {
                AuthApiUrl = new Uri("http://host.docker.internal:8080/api/auth/");
                AuthOperationClaimsApiUrl = new Uri("http://host.docker.internal:8080/api/operationClaims/");
                AuthUserApiUrl = new Uri("http://host.docker.internal:8080/api/users/");
                AuthUserOperationClaimsApiUrl = new Uri("http://host.docker.internal:8080/api/userOperationClaims/");

                MeterApiUrl = new Uri("http://host.docker.internal:8090/api/meters/");
                MeterBrandApiUrl = new Uri("http://host.docker.internal:8090/api/brands/");
                MeterModelApiUrl = new Uri("http://host.docker.internal:8090/api/models/");
                MeterReadingTimeApiUrl = new Uri("http://host.docker.internal:8090/api/readingTimes/");

                ReadingApiUrl = new Uri("http://host.docker.internal:8010/api/readings/");

                ModemApiUrl = new Uri("http://host.docker.internal:8100/api/modems/");
                ModemBrandApiUrl = new Uri("http://host.docker.internal:8100/api/brands/");
                ModemModelApiUrl = new Uri("http://host.docker.internal:8100/api/models/");

                CustomerApiUrl = new Uri("http://host.docker.internal:8070/api/customers/");
            }
        }
    }
}
