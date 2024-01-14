namespace HRM.Shared.Models;

public sealed class Paginator
{
    private int _size = 100;

    public int PageSize
    {
        get
        {
            return _size;
        }
        set
        {
            _size = value < 1 || value > _size ? _size : value;
        }
    }

    private int _page = 1;

    public int PageNumber
    {
        get
        {
            return _page;
        }
        set
        {
            _page = value < 1 ? 1 : value;
        }
    }
}
