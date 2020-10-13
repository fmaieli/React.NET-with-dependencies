using System.Web;
using System.Web.Optimization;
using System.Web.Optimization.React;

namespace Project.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new BabelBundle("~/bundles/react_development")
                .Include(
                    "~/Scripts/React/dependencies/react-development/react.development.js",
                    "~/Scripts/React/dependencies/react-development/react-dom.development.js",
                    "~/Scripts/React/dependencies/react-development/remarkable.min.js" // este .js se podria sacar en caso de no usar Remarkable pero es necesario para Tutorial.jsx
                )
            );

            bundles.Add(new BabelBundle("~/bundles/react_production")
                .Include(
                    "~/Scripts/React/dependencies/react-production/react.production.min.js",
                    "~/Scripts/React/dependencies/react-production/react-dom.production.min.js",
                    "~/Scripts/React/dependencies/react-production/remarkable.min.js" // este .js se podria sacar en caso de no usar Remarkable pero es necesario para Tutorial.jsx
                )
            );

            bundles.Add(new BabelBundle("~/bundles/react_components")
                .Include(
                    // Se debe de tener en cuenta los components que dependen de otros en el orden de los scripts
                    "~/Scripts/React/components/example-component-with-styled-components/StyledComponentsExample.jsx",
                    "~/Scripts/React/components/example-component1/Example2.jsx",
                    "~/Scripts/React/components/example-component1/Example1.jsx"
                )
            );

            // Forces files to be combined and minified in debug mode
            // Only used here to demonstrate how combination/minification works
            // Normally you would use unminified versions in debug mode.
            // EnableOptimizations = true => minification
            // EnableOptimizations = false => muestra los components como .jsx en el developer tools
            BundleTable.EnableOptimizations = true;
        }
    }
}
