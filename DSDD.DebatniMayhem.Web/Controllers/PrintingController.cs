using DSDD.DebatniMayhem.Web.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace DSDD.DebatniMayhem.Web.Controllers;

[Route("print")]
public class PrintingController : Controller
{
    public PrintingController(MayhemDbContext dbContext, IOptions<PrintingConfiguration> options)
    {
        _dbContext = dbContext;
        _options = options;
    }

    [HttpGet("{roundId:int}")]
    public async Task<IActionResult> PrintAsync(int roundId, [FromQuery] string? key)
    {
        if (key != _options.Value.Key)
            throw new InvalidOperationException("Mismatch between printing keys!");

        IReadOnlyList<OngoingMatch> ongoingMatches = await _dbContext
            .Rounds
            .Where(r => r.Id == roundId)
            .SelectMany(r => r.Matches.Select(m => new OngoingMatch(
                r.Id,
                r.Topic,

                m.Id,
                m.Room.Name,

                m.Og1Navigation.Name,
                m.Og1Navigation.Placeholder,
                m.Og2Navigation.Name,
                m.Og2Navigation.Placeholder,

                m.Oo1Navigation.Name,
                m.Oo1Navigation.Placeholder,
                m.Oo2Navigation.Name,
                m.Oo2Navigation.Placeholder,

                m.Cg1Navigation.Name,
                m.Cg1Navigation.Placeholder,
                m.Cg2Navigation.Name,
                m.Cg2Navigation.Placeholder,

                m.Co1Navigation.Name,
                m.Co1Navigation.Placeholder,
                m.Co2Navigation.Name,
                m.Co2Navigation.Placeholder)))
            .ToArrayAsync();

        Document document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A5);
                page.Margin(0.25f, Unit.Inch);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12).FontFamily());
                 
                page.Content()
                    .Column(column =>
                    {
                        foreach (OngoingMatch match in ongoingMatches)
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(4);
                                    columns.RelativeColumn(4);
                                    columns.RelativeColumn(4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(cellStyle).Text("Místnost").ExtraBold();
                                    header.Cell().Element(cellStyle).Text("Round ID");
                                    header.Cell().Element(cellStyle).Text("Match ID");
                                });

                                table.Cell().Element(cellStyle).Text(match.Room).ExtraBold();
                                table.Cell().Element(cellStyle).Text(match.RoundId.ToString());
                                table.Cell().Element(cellStyle).Text(match.MatchId.ToString());
                            });

                            column.Item().Padding(10);

                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn(11);
                                });
                                 
                                table.Cell().Element(cellStyle).Text("Rozhodčí").ExtraBold();
                                table.Cell().Element(cellStyle);
                            });

                            column.Item().Padding(10);

                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(cellStyle).Text("Teze").ExtraBold();
                                });

                                table.Cell().Element(cellStyle).Text(match.Topic).FontSize(10);
                            });
                            
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn(8);
                                    columns.RelativeColumn(3);
                                });
                                
                                table.Header(header =>
                                {
                                    header.Cell().Element(cellStyle).Text("Pozice").ExtraBold();
                                    header.Cell().Element(cellStyle).Text("Body").ExtraBold();
                                    header.Cell().Element(cellStyle).Text("Debatér").ExtraBold();
                                    header.Cell().Element(cellStyle).Text("SP").ExtraBold();
                                });

                                table.Cell().RowSpan(2).Element(cellStyleCenter).Text("OG");
                                table.Cell().RowSpan(2).Element(cellStyle);
                                table.Cell().Element(cellStyle).Text(getNameIfNotPlaceholder(match.Og1, match.Og1Placeholder));
                                table.Cell().Element(cellStyle);
                                table.Cell().Element(cellStyle).Text(getNameIfNotPlaceholder(match.Og2, match.Og2Placeholder));
                                table.Cell().Element(cellStyle);

                                table.Cell().RowSpan(2).Element(cellStyleCenter).Text("OO");
                                table.Cell().RowSpan(2).Element(cellStyle);

                                table.Cell().Element(cellStyle).Text(getNameIfNotPlaceholder(match.Oo1, match.Oo1Placeholder));
                                table.Cell().Element(cellStyle);
                                table.Cell().Element(cellStyle).Text(getNameIfNotPlaceholder(match.Oo2, match.Oo2Placeholder));
                                table.Cell().Element(cellStyle);

                                table.Cell().RowSpan(2).Element(cellStyleCenter).Text("CG");
                                table.Cell().RowSpan(2).Element(cellStyle);
                                table.Cell().Element(cellStyle).Text(getNameIfNotPlaceholder(match.Cg1, match.Cg1Placeholder));
                                table.Cell().Element(cellStyle);
                                table.Cell().Element(cellStyle).Text(getNameIfNotPlaceholder(match.Cg2, match.Cg2Placeholder));
                                table.Cell().Element(cellStyle);

                                table.Cell().RowSpan(2).Element(cellStyleCenter).Text("CO");
                                table.Cell().RowSpan(2).Element(cellStyle);
                                table.Cell().Element(cellStyle).Text(getNameIfNotPlaceholder(match.Co1, match.Co1Placeholder));
                                table.Cell().Element(cellStyle);
                                table.Cell().Element(cellStyle).Text(getNameIfNotPlaceholder(match.Co2, match.Co2Placeholder));
                                table.Cell().Element(cellStyle);

                                table.Cell();
                                table.Cell().Text("Hodnoty jsou\r\n3, 2, 1, 0.\r\nVýherce dostane 3.\r\nPoslední tým dostane 0.").FontSize(10);
                                table.Cell();
                                table.Cell().Text("Rozmezí je\r\n 60 až 90 včetně.").FontSize(10);
                            });

                            if (match != ongoingMatches.Last())
                                column.Item().PageBreak();

                            static IContainer cellStyle(IContainer container)
                                => container
                                    .Border(0.5f)
                                    .BorderColor("#808080")
                                    .PaddingHorizontal(0.5f, Unit.Centimetre)
                                    .PaddingVertical(0.25f, Unit.Centimetre)
                                    .AlignMiddle();

                            static IContainer cellStyleCenter(IContainer container)
                                => cellStyle(container).AlignCenter();

                            static string getNameIfNotPlaceholder(string name, bool placeholder)
                                => placeholder ? "" : name;
                        }
                    });
            });
        });

        Response.Headers["Content-Disposition"] = $"inline; filename=Round {roundId}.pdf";

        return File(document.GeneratePdf(), "application/pdf");
    }

    private readonly MayhemDbContext _dbContext;
    private readonly IOptions<PrintingConfiguration> _options;

    public class PrintingConfiguration
    {
        public string? Key { get; set; }
    }

    private class OngoingMatch
    {
        public int RoundId { get; }
        public string Topic { get; }

        public int MatchId { get; }
        public string Room { get; }

        public string Og1 { get; }
        public bool Og1Placeholder { get; }
        public string Og2 { get; }
        public bool Og2Placeholder { get; }

        public string Oo1 { get; }
        public bool Oo1Placeholder { get; }
        public string Oo2 { get; }
        public bool Oo2Placeholder { get; }

        public string Cg1 { get; }
        public bool Cg1Placeholder { get; }
        public string Cg2 { get; }
        public bool Cg2Placeholder { get; }

        public string Co1 { get; }
        public bool Co1Placeholder { get; }
        public string Co2 { get; }
        public bool Co2Placeholder { get; }

        public OngoingMatch(int roundId, string topic, int matchId, string room,
            string og1, bool og1Placeholder, string og2, bool og2Placeholder, string oo1,
            bool oo1Placeholder, string oo2, bool oo2Placeholder, string cg1, bool cg1Placeholder, string cg2, bool cg2Placeholder, string co1, bool co1Placeholder, string co2, bool co2Placeholder)
        {
            RoundId = roundId;
            Topic = topic;
            MatchId = matchId;
            Room = room;
            Og1 = og1;
            Og1Placeholder = og1Placeholder;
            Og2 = og2;
            Og2Placeholder = og2Placeholder;
            Oo1 = oo1;
            Oo1Placeholder = oo1Placeholder;
            Oo2 = oo2;
            Oo2Placeholder = oo2Placeholder;
            Cg1 = cg1;
            Cg1Placeholder = cg1Placeholder;
            Cg2 = cg2;
            Cg2Placeholder = cg2Placeholder;
            Co1 = co1;
            Co1Placeholder = co1Placeholder;
            Co2 = co2;
            Co2Placeholder = co2Placeholder;
        }
    }
}

