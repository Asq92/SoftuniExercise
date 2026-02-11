public class Program
{
    public static void Main(string[] args)
    {
        int countSongs = int.Parse(Console.ReadLine());

        List<Song> songList = new List<Song>();

        for (int count = 1; count <= countSongs; count++)
        {
            string data = Console.ReadLine();
            string typeList = data.Split("_")[0];
            string name = data.Split("_")[1];
            string time = data.Split("_")[2];

            Song song = new Song(typeList, name, time);
            songList.Add(song);
        }

        string choosenPlaylist = Console.ReadLine();

        foreach (Song song in songList)
        {
            if (song.TypeList == choosenPlaylist || choosenPlaylist == "all")
            {
                Console.WriteLine(song.Name);
            }
        }
    }
}

