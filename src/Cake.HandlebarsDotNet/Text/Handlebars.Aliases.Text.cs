using System;
using Cake.Core.Annotations;

namespace Cake.HandlebarsDotNet
{
    partial class HandlebarsAliases
    {
        /// <summary>
        /// Renders the template and data to a string
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="template">String representation of a Handlebars template</param>
        /// <param name="data">Object to supply to the Handlebars template</param>
        [CakeMethodAlias]
        public static string HandlebarsRenderText(this Cake.Core.ICakeContext context, string template, object data)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var compiled = global::HandlebarsDotNet.Handlebars.Compile(template);

            return compiled(data);
        }
    }
}