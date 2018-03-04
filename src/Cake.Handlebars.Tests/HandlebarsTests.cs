using System.IO;
using Cake.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cake.Handlebars.Tests
{
    [TestClass]
    public class HandlebarsTests
    {
        private readonly object Data = new
        {
            Name = "Human",
            Nicknames = new[]
            {
                "Person",
                "Being",
                "Lifeform",
            }
        };
        private const string TemplateText = @"Hello, {{Name}}! (a.k.a.{{#Nicknames}} {{this}}{{/Nicknames}})";
        private const string TemplateFile = "./template.handlebars";
        private const string Expected = "Hello, Human! (a.k.a. Person Being Lifeform)";
        private ICakeContext context;

        [TestInitialize]
        public void SetUp()
        {
            context = new HandlebarsTestFixture();
        }

        [TestMethod]
        public void ShouldRenderTextTemplate()
        {
            var actual = context.HandlebarsRenderText(TemplateText, Data);
            actual.Should().Be(Expected);
        }

        [TestMethod]
        public void ShouldRenderTextFileTemplate()
        {
            var actual = context.HandlebarsRenderTextFile(TemplateFile, Data);
            actual.Should().Be(Expected);
        }

        [TestMethod]
        public void ShouldRenderTextFileTemplateToFile()
        {
            context.HandlebarsRenderTextFile(TemplateFile, "./actual.txt", Data);
            var actual = File.ReadAllText("./actual.txt");
            actual.Should().Be(Expected);
        }
    }
}
