using System.Text;

namespace PlaywrightBDD.Helpers
{
    public static class AxeHtmlReportGenerator
    {
        public static void GenerateHtmlReport(Deque.AxeCore.Commons.AxeResult results, string filePath, string reportName)
        {
            var html = new StringBuilder();

            html.AppendLine("<html><head><title> Accessibility Report </title></head><body>");
            html.AppendLine("<h1> Accessibility Violations: " + reportName + "</h1>");
            html.AppendLine("<table border='1' cellpadding='10' cellspacing='0'>");
            html.AppendLine("<tr><th>Issue Id</th><th>Description</th><th>Help</th><th>HelpUrl</th><th>Impact</th><th>Tags</th><th>Target</th><th>Message</th><th>Html</th><th>Data</th></tr>");
            if (results.Violations != null && results.Violations.Count() > 0)
            {
                foreach (var violation in results.Violations)
                {
                    int i = 0;
                    foreach (var node in violation.Nodes)
                    {
                        html.AppendLine("<tr>");
                        html.AppendLine($"<td>{violation.Id}</td>");
                        html.AppendLine($"<td>{violation.Description}</td>");
                        html.AppendLine($"<td>{violation.Help}</td>");
                        html.AppendLine($"<td>{violation.HelpUrl}</td>");
                        html.AppendLine($"<td>{violation.Impact}</td>");
                        html.AppendLine($"<td>{string.Join(", ", violation.Tags)}</td>");
                        html.AppendLine($"<td>{string.Join(", ", node.Target)}</td>");
                        html.AppendLine($"<td>{violation.Nodes[i].Any[0].Message}</td>");
                        html.AppendLine($"<td>{violation.Nodes[i].Html.ToString()}</td>");
                        html.AppendLine($"<td>{violation.Nodes[i].Any[0].Data}</td>");
                        html.AppendLine("</tr>");
                        i = i + 1;
                    }
                }
            }
            else
            {
                html.AppendLine("<p>No accessibility violations found.</p>");
            }
            html.AppendLine("</table></body></html>");
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, html.ToString());
        }
    }
}
