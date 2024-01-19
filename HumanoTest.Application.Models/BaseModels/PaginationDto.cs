namespace HumanoTest.Application.Models.BaseModels;

public class PaginationDto
{
    public PaginationDto()
    {
    }

    public PaginationDto(int page, int take)
    {
        Page = page;
        Take = take;
    }

    public int Page { get; set; } = 1;

    public int Take { get; set; } = 10;
}