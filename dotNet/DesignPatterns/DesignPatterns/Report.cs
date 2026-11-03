namespace DesignPatterns;

public interface IReport
{
    string Render(string title);
}

public class PdfReport : IReport
{
    public string Render(string title) => $"[PDF] {title}";
}

public class HtmlReport : IReport
{
    public string Render(string title) => $"<h1>{title}</h1>";
}

public abstract class ReportFactory
{
    public abstract IReport CreateReport();

    public void Export(string title)
    {
        IReport report = CreateReport();
        Console.WriteLine(report.Render(title));
    }
}

public class PdfReportFactory : ReportFactory
{
    public override IReport CreateReport() => new PdfReport();
}

public class HtmlReportFactory : ReportFactory
{
    public override IReport CreateReport() => new HtmlReport();
}

public class Report
{
    public static void Run()
    {
        ReportFactory[] factories = [new PdfReportFactory(), new HtmlReportFactory()];
        foreach (ReportFactory factory in factories)
        {
            factory.Export("Sales Q3");
        }
    }
}