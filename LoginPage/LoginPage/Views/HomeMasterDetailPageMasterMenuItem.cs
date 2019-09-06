using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage.Views
{

    public class HomeMasterDetailPageMasterMenuItem
    {
        public HomeMasterDetailPageMasterMenuItem()
        {
            TargetType = typeof(HomeMasterDetailPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}