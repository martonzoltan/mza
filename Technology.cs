using System.ComponentModel;

namespace PersonalSite;

public enum Technology
{
    [Description("csharp")] Csharp,
    [Description("dotnetcore")] DotNetCore,
    [Description("microsoftsqlserver")] Msql,
    [Description("html5")] Html5,
    [Description("javascript")] JavaScript,
    [Description("angularjs")] Angular,
    [Description("vuejs")] VueJs,
    [Description("postgresql")] PostgreSql,
    [Description("mongodb")] MongoDb,
    [Description("azure")] Azure,
    [Description("css3")] Css,
    [Description("github")] Github,
    [Description("gulp")] Gulp,
    [Description("sass")] Sass,
    [Description("python")] Python
}