using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListDatabase : MonoBehaviour {

	public List<ListData> listDb = new List<ListData> ();

	void Start () {
		listDb.Add (new ListData(0,"ANJURAN SHALAT MALAM", "Imam Ahmad, Ibnu Nashar dan Thabrani dari Ibnu Abbas", true, false));
		listDb.Add (new ListData(1,"TAYAMUM", "Imam Ahmad, Ibnu Rahawaih, Al Baihaqi dari Abu Hurairah", true, false));
		listDb.Add (new ListData(2,"BERWUDHU SATU KALI", "Imam Ahmad, Muslim dan Imam Hadits Yang Empat dan Buraidah bin Husshaib", true, false));
		listDb.Add (new ListData(3,"DOA PAGI DAN PETANG", "Imam Ahmad, Abu Daud, Tirmizi, Ibnu Hibban, Al Hakim dan Abu Hurairah", true, false));
		listDb.Add (new ListData(4,"DOA DALAM SHALAT", "Imam Ahmad, Imam Hadits Yang Empat selain Abu Daud dari Umar r.a.", true, false));
		listDb.Add (new ListData(5,"ISTIQAMAH","Imam Ahmad, Muslim, Imam Hadits Yang Empat kecuali Abu Daud dari Sufyan bin Abdullah Ats Tsaqafi", true, false));
		listDb.Add (new ListData(6,"SHALAT ITU OBAT", "Imam Ahmad dan Ibnu Majah dari Abu Hurairah r.a.", true, false));
		listDb.Add (new ListData(7,"MAHAR DENGAN AYAT AL QUR'AN", "Abu Daud dari Abu Hurairah", true, false));
		listDb.Add (new ListData(8,"SHALAT DENGAN SELEMBAR KAIN", "Ibnu Hibban dari Abu Hurairah", true, false));
		listDb.Add (new ListData(9,"DILARANG MEMBUNUH ORANG KAFIR", "Imam Ahmad, Bukhari, Muslim dan Abu Daud dari Miqdad Ibnu Amru al Kindy r.a.", true, false));
		listDb.Add (new ListData(10,"MAKAN BERJAMA'AH", "Imam Ahmad, Abu Daud, Ibnu Majah, Tur-midzi, At Thabrani, Ibnu Hibban, Al Baihaqi, semuanya dari Wahsya bin Harb. Menurut Al Hafizh Al Iraqi, isnadnya hasan", true, false));
		listDb.Add (new ListData(11,"MEMBERI MAKAN ORANG SAKIT", "Ibnu Majah dan Ibnu Abbas. Dalam sanadnya ada orang bemama Shafwan bin Habirah yang dilemahkan oleh Ad Dzahabi.", true, false));
		listDb.Add (new ListData(12,"DOA MAKAN DAN MINUM", "Imam Ahmad, Abu Daud, At Turmidzi, Ibnu Majah, Al Baihaqi dalam \"As Syi 'ib\" dan Ibnu Abbas. Menurut At Turmidzi, hadits ini hasan.", true, false));
		listDb.Add (new ListData(13,"BERKUMUR SETELAH MINUM SUSU", "Ibnu Majah dari Ummu Salamah. Menurut pensyarahnya, isnad Hadits ini bagus.", true, false));
		listDb.Add (new ListData(14,"CARA MAKAN", "Ibnu Majah dan Ibnu Abbas. As Suyuthi memasukkan Hadits ini ke dalam Hadits hasan.", true, false));
		listDb.Add (new ListData(15,"PUASA NABI ABU DAUD", "Abu Daud dari Abu Hurairah", true, false));

	}
}
