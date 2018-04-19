using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Entities;
using System.Data.SqlClient;

namespace DataAccess.Content
{
    public class ContentRepo
    {
        /// <summary>
        /// Get all CORE Contents
        /// </summary>
        /// <returns></returns>
        public List<COREContent> GetCoreContents()
        {
            return new AppsContext().CoreContents.ToList();
        }

        /// <summary>
        /// Get one content out by its ID
        /// </summary>
        /// <param name="contentID">content id is the unique content Identifier</param>
        /// <returns>Single COREContent Model</returns>
        public COREContent GetCoreContentByID(int contentID)
        {
            return new AppsContext().CoreContents
                .First(i => i.CONTENTID == contentID);
        }
       
        /// <summary>
        /// Get Content by validity
        /// </summary>
        /// <param name="isActive">Defaul</param>
        /// <returns></returns>
        public List<COREContent> GetValidCoreContents(bool isActive = true)
        {
            return new AppsContext().CoreContents
                .Where(i => i.CONTENTIsActive == isActive)
                .ToList();
        }

    }
}
