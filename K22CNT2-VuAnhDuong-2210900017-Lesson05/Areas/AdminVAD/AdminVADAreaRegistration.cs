using System.Web.Mvc;

namespace K22CNT2_VuAnhDuong_2210900017_.Areas.AdminVAD
{
    public class AdminVADAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminVAD";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AdminVAD_default",
                "AdminVAD/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "K22CNT2_VuAnhDuong_2210900017_.Areas.AdminVAD.Controllers" } // Namespace cho các controller trong area AdminVAD
            );
        }

    }
}