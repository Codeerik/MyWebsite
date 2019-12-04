using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErikVanDelft.Helpers
{
    public static class HtmlHelpers
    {
        /// <summary>
        /// Determines whether the specified action and controller is currently in view.
        /// </summary>
        /// <param name="html">The HTML helper.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <remarks>
        /// http://www.sweet-web-design.com/wordpress/how-to-add-active-class-to-menu-tab-in-asp-net-mvc/2954/
        /// </remarks>
        /// <returns>The css class to add to the HTML element if it is the active navigation.</returns>
        public static string IsSelected(this IHtmlHelper html, string action = null, string controller = null)
        {
            const string cssClass = "selected";
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
            {
                controller = currentController;
            }

            if (String.IsNullOrEmpty(action))
            {
                action = currentAction;
            }

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }
    }



}
