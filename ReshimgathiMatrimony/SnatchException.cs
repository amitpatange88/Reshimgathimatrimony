using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace ReshimgathiMatrimony
{
    public class SnatchException : FilterAttribute, IExceptionFilter
    {

        public void OnException(ExceptionContext filterContext)
        {
            Log(filterContext);
        }

        private void Log(ExceptionContext filterContext)
        {
            //log exception here..
            FileUtility file = new FileUtility();
            string path = file.Path + string.Format(file.Name, DateTime.Now.ToString("yyyyMMdd"));

            var data = new LogErrorFields
                {
                    DateTime = DateTime.Now.ToString(),
                    NameSpace = filterContext.Controller.ToString(),
                    ErrorCode = filterContext.Exception.HResult.ToString(),
                    Exception = filterContext.Exception.Message};
            string json = JsonConvert.SerializeObject(data);

            file.CreateFile(path, json);
        }
    }

    public class LogErrorFields
    {
        public string DateTime { get; set; }

        public string NameSpace { get; set; }

        public string Exception { get; set; }

        public string ErrorCode { get; set; }

    }
}