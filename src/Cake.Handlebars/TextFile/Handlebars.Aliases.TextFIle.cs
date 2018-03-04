using System;
using System.IO;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Handlebars
{
    partial class HandlebarsAliases
    {
        /// <summary>
        /// Renders the templateFile and data to a string
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="templateFile">File to read Handlebars template from</param>
        /// <param name="data">Object to supply to the Handlebars template</param>
        [CakeMethodAlias]
        public static string HandlebarsRenderTextFile(this Cake.Core.ICakeContext context, FilePath templateFile, object data)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var template = File.ReadAllText(templateFile.FullPath);

            return context.HandlebarsRenderText(template, data);
        }

        /// <summary>
        /// Renders the templateFile and data to targetFile
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="templateFile">File to read Handlebars template from</param>
        /// <param name="targetFile">File to write rendered template to</param>
        /// <param name="data">Object to supply to the Handlebars template</param>
        [CakeMethodAlias]
        public static void HandlebarsRenderTextFile(this Cake.Core.ICakeContext context, FilePath templateFile, FilePath targetFile, object data)
        {
            var contents = context.HandlebarsRenderTextFile(templateFile, data);
            
            File.WriteAllText(targetFile.FullPath, contents);
        }
    }
}