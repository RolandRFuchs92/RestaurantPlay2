using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Content;

namespace DataAccessConsole.Content
{
    public class Content
    {
        private  ContentRepo contentRepo { get; set; }

        public  Content()
        {
            contentRepo = new ContentRepo();
        }

        public string GetCoreContents()
        {
            return string.Join("\n\r",contentRepo.GetCoreContents().Select(i => i.CONTENTValue).ToArray());
        }

        public string GetCoreContentByID()
        {
            return contentRepo.GetCoreContentByID(1).ToString();
        }

        public string GetValidCoreContents()
        {
            return string.Join("\r\n", contentRepo.GetValidCoreContents().Select(i => i.CONTENTValue).ToArray());
        }

    }
}
