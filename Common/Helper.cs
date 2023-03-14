namespace Quiz.Common
{
    public class Helper
    {
        public static IEnumerable<int> GetEnumValues<T>()
        {
            return System.Enum.GetValues(typeof(T))
    .Cast<T>()
    .Select(x => Convert.ToInt32(x))
    .ToList();
        }

        public static IEnumerable<string?> GetEnumNames<T>()
        {
            return System.Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(v => v.ToString())
                .ToList();
        }
    }
}
