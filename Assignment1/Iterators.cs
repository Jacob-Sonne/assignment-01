namespace Assignment1;

public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items){
        foreach(var lst in items){
            foreach(var item in lst){
                yield return item;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate){
        foreach(var item in items){
            if(predicate(item)){
                yield return item;
            }
        }
    }
}