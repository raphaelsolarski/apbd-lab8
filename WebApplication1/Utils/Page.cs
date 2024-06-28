namespace WebApplication1.Utils;

public class Page<TV>(
    int pageNum,
    int pageSize,
    int allPages,
    ICollection<TV> content
)
{
    public int PageNum => pageNum;
    public int PageSize => pageSize;
    public int AllPages => allPages;
    public ICollection<TV> Content => content;
}