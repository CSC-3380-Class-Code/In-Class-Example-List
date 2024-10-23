using System;

public class List<Type> where Type : IComparable{
	public Type[] list;
	private int size;

	public List(){
		list = [];
		size = 0;
	}

	public List(Type[] arr){
		list = arr;
		size = arr.Length;
	}

	public static List<Type> operator +(List<Type> l, Type elem){
		int return_size = 1+l.size;
		Type[] return_list = new Type[return_size];

		for(int i = 0; i < l.size; i++){
			return_list[i] = l.list[i];
		}
		return_list[return_size-1] = elem;
		return new List<Type>(return_list);
	}

	public static List<Type> operator +(List<Type> l1, List<Type> l2){
		foreach(Type val in l2.list){
			l1 += val;
		}
		return l1;
	}

	public int Index(){
		return list.Length;
	}

	public bool Sort(){
		for(int i = 0; i < list.Length-1; i++){
			for(int j = i+1; j < list.Length; j++){
				if(list[i].CompareTo(list[j]) > -1){
					Type temp = list[i];
					list[i] = list[j];
					list[j] = temp;
				}
			}
		}

		return true;
	}

    public override string ToString()
    {
		string return_string = "[";
		foreach(Type val in list){
			return_string += $"{val},";
		}

		return_string += "]";

        return return_string;
    }



}

public class ListTest{
	public static void Main(){
		int[] arr = {0,2,1,3};
		int elem = 5;

		List<int> l = new List<int>(arr);
		Console.WriteLine(l);

		l = l + elem;
		Console.WriteLine(l);

		l = l + l;
		Console.WriteLine(l);

		l.Sort();
		Console.WriteLine(l);

		string[] str_arr = {"1", "Hello"};
		string str1 = "HI";

		List<string> l2 = new List<string>(str_arr);
		Console.WriteLine(l2);

		l2 = l2 + str1;
		Console.WriteLine(l2);

		l2 = l2 + l2;
		Console.WriteLine(l2);

	}
}