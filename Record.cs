using System;
using System.Linq;
using System.Collections.Generic;

public class Record
{
    public string albumName = { get; set; }
    public string artist = { get; set; }
    public int yearReleased = { get; set;}

    public Record(string albumName, string artist, int yearReleased)
    {
        this.albumName = albumName;
        this.artist = artist;
        this.yearReleased = yearReleased;
    }

var recordList = new List<Record> {
    new Record { albumName = "Thriller", artist = "Michael Jackson", yearReleased = 1982 },
    new Record { albumName = "Back in Black", artist = "AC/DC", yearReleased = 1980 },
    new Record { albumName = "The Dark Side of the Moon", artist = "Pink Floyd", yearReleased = 1973 },
    new Record { albumName = "Abbey Road", artist = "The Beatles", yearReleased = 1969 },
    new Record { albumName = "Hotel California", artist = "Eagles", yearReleased = 1976 },
    new Record { albumName = "Led Zeppelin IV", artist = "Led Zeppelin", yearReleased = 1971 },
    new Record { albumName = "Rumours", artist = "Fleetwood Mac", yearReleased = 1977 },
    new Record { albumName = "The Wall", artist = "Pink Floyd", yearReleased = 1979 },
    new Record { albumName = "Born to Run", artist = "Bruce Springsteen", yearReleased = 1975 },
    new Record { albumName = "The Joshua Tree", artist = "U2", yearReleased = 1987 },
    new Record { albumName = "Purple Rain", artist = "Prince", yearReleased = 1984 },
    new Record { albumName = "Sgt. Pepper's Lonely Hearts Club Band", artist = "The Beatles", yearReleased = 1967 },
    new Record { albumName = "A Night at the Opera", artist = "Queen", yearReleased = 1975 },
    new Record { albumName = "Nevermind", artist = "Nirvana", yearReleased = 1991 },
    new Record { albumName = "The Rise and Fall of Ziggy Stardust and the Spiders from Mars", artist = "David Bowie", yearReleased = 1972 },
    new Record { albumName = "The Chronic", artist = "Dr. Dre", yearReleased = 1992 },
    new Record { albumName = "London Calling", artist = "The Clash", yearReleased = 1979 },
    new Record { albumName = "Graceland", artist = "Paul Simon", yearReleased = 1986 },
    new Record { albumName = "Blood on the Tracks", artist = "Bob Dylan", yearReleased = 1975 },
    new Record { albumName = "The Doors", artist = "The Doors", yearReleased = 1967 },
    new Record { albumName = "Darkness on the Edge of Town", artist = "Bruce Springsteen", yearReleased = 1978 },
    new Record { albumName = "Born in the U.S.A.", artist = "Bruce Springsteen", yearReleased = 1984 },
    new Record { albumName = "The Velvet Underground & Nico", artist = "The Velvet Underground", yearReleased = 1967 },
    new Record { albumName = "Songs in the Key of Life", artist = "Stevie Wonder", yearReleased = 1976 },
    new Record { albumName = "The Clash", artist = "The Clash", yearReleased = 1977 },
    new Record { albumName = "Bridge Over Troubled Water", artist = "Simon & Garfunkel", yearReleased = 1970 },
    new Record { albumName = "Are You Experienced", artist = "The Jimi Hendrix Experience", yearReleased = 1967 },
    new Record { albumName = "Born to Die", artist = "Lana Del Rey", yearReleased = 2012 },
    new Record { albumName = "Ten", artist = "Pearl Jam", yearReleased = 1991 },
    new Record { albumName = "Court and Spark", artist = "Joni Mitchell", yearReleased = 1974 },
    new Record { albumName = "Aja", artist = "Steely Dan", yearReleased = 1977 },
    new Record { albumName = "Back to Black", artist = "Amy Winehouse", yearReleased = 2006 },
    new Record { albumName = "Kind of Blue", artist = "Miles Davis", yearReleased = 1959 },
    new Record { albumName = "Wish You Were Here", artist = "Pink Floyd", yearReleased = 1975 },
    new Record { albumName = "Pet Sounds", artist = "The Beach Boys", yearReleased = 1966 },
    new Record { albumName = "American Idiot", artist = "Green Day", yearReleased = 2004 },
    new Record { albumName = "The Queen Is Dead", artist = "The Smiths", yearReleased = 1986 },
    new Record { albumName = "Sign o' the Times", artist = "Prince", yearReleased = 1987 },
    new Record { albumName = "Thriller", artist = "Michael Jackson", yearReleased = 1982 },
    new Record { albumName = "The Marshall Mathers LP", artist = "Eminem", yearReleased = 2000 }
    }
    
    var recordsAfter1980 = recordList.Where(r => r.yearReleased > 1990);
}