namespace Tasks.AssembLy.Intepreter.Extensions
{
    // https://stackoverflow.com/a/47816647
    public static class Extensions
    {
        public static void Deconstruct<T>(this IList<T> list, out T first, out IList<T> rest)
        {
            first = list.Count > 0 ? list[0] : throw new ArgumentOutOfRangeException();
            rest = list.Skip(1).ToList();
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out IList<T> rest)
        {
            first = list.Count > 0 ? list[0] : throw new ArgumentOutOfRangeException();
            second = list.Count > 1 ? list[1] : throw new ArgumentOutOfRangeException();
            rest = list.Skip(2).ToList();
        }
    }
}
