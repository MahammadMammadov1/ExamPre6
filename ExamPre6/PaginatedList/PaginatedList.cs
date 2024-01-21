namespace ExamPre6.PaginatedList
{
    public class PaginatedList <T> : List<T> 
    {
        public PaginatedList(List<T> datas,int page,int count,int pageSize)
        {
            AddRange(datas);
            ActivePage = page;
            TotalCount = (int)(Math.Ceiling(count / (double)pageSize));
        }

        public int ActivePage { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext 
        {
            get
            {
                return ActivePage<TotalCount;
            }
        }
        public bool HasPrev
        {
            get
            {
                return ActivePage > 1;
            }
        }
    }
}
