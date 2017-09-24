var imageFile;
var imageUrl;

(function(){
	var database = firebase.database();
	var ref = database.ref();
	ref.on('value', gotData, errData);
	
	var uploader = document.getElementById('uploader');
	var fileButton = document.getElementById('fileButton');
	
	fileButton.addEventListener('change', function(e) {
		
		//GET FILE
		//var file = e.target.files[0];
		imageFile = e.target.files[0];
	});

}());

//HOLDER BUTTON "NEW DATA"
function new_data(){
	
	// Get the modal
	var modal = document.getElementById('new_modal');
	
	// Get the <span> element that closes the modal
	var span = document.getElementsByClassName("close")[0];
	
	//Open the modal
	modal.style.display = "block";
	
	// When the user clicks on <span> (x), close the modal
	span.onclick = function() {
		modal.style.display = "none";
	}

	// When the user clicks anywhere outside of the modal, close it
	window.onclick = function(event) {
		if (event.target == modal) {
			modal.style.display = "none";
		}
	}
};

//HOLDER BUTTON "SAVE" PADA MODAL NEW DATA
function save_data(){
	
	if(fileButton.value =="" || title.value =="" || kategori.value =="" || perawi.value =="" || teks.value ==""){
		alert('Semua field harus terisi!');
	}
	else{
		
		// CREATE REF
		var storageRef = firebase.storage().ref('Ayat/' + imageFile.name);
		
		// UPLOAD FILE
		var task = storageRef.put(imageFile);
		
		// UPDATE PROGRESS BAR
		task.on('state_changed',
			
			function progress(snapshot) {
				var percentage = (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
				uploader.value = percentage;
			},
			
			function error(err) {
				alert('Gambar gagal Upload!');
			},
			
			function complete() {
				
				//GET METADATA FILE STORAGE
				var ayatRef = firebase.storage().ref().child('Ayat/' + imageFile.name);
				ayatRef.getMetadata().then(function(metadata) {
					console.log(metadata);
					imageUrl = metadata.downloadURLs[0];
				  
				  	var database =  firebase.database();
					var data = {
						title: title.value,
						kategori: kategori.value,
						perawi: perawi.value,
						teks: teks.value,
						url_ayat: imageUrl
					}
					database.ref().push(data,checkerror);
				  
				}).catch(function(error) {
				  // Uh-oh, an error occurred!
				});
			}
		);	
	}
};

//CALLBACK CEK ERROR NEW DATA
function checkerror(error){
	if(error){
		alert('Input Data Gagal!');
	}else{
		alert('Data berhasil di Input!');
		location.reload();
	}
};

//DISPLAY DATA
function gotData(data){
	var db = data.val();
	var keys = Object.keys(db);
	
	for(var i = 0; i < keys.length; i++){
		var k = keys[i];
		var title = db[k].title;
		showDatabase(k, title);
	}
};

//DISPLAY DATA
function showDatabase(key, title){
	var li = document.createElement('li');
	var a = document.createElement('a');
	var t = document.createTextNode(' ' + title);
	
	a.appendChild(t);
	li.appendChild(a);
	
	var list = document.getElementById('listData');
	list.appendChild(li);
	
	a.href = '#';
	a.onclick = function() {
		editData(key);
	}
};

//JIKA LOAD DATA GAGAL
function errData(err){
	console.log('Error!');
	console.log(err);
};

//POPUP MODAL "EDIT DATA"
function editData (t) {

	var database = firebase.database();
	var data = database.ref().child(t);
	//data.on('value', snap => console.log(snap.val().title));
	data.on('value', snap => {

		edit_title.value = snap.val().title;
		edit_kategori.value = snap.val().kategori;
		edit_perawi.value = snap.val().perawi;
		edit_teks.value = snap.val().teks;
		btn_update.onclick = function () {
			update_data(t);
		} 
		btn_delete.onclick = function () {
			deleteData(t);
		}
	});
	
	// Get the modal
	var modal = document.getElementById('edit_modal');
	
	// Get the <span> element that closes the modal
	var span = document.getElementsByClassName("close")[1];
	
	//Open the modal
	modal.style.display = "block";
	
	// When the user clicks on <span> (x), close the modal
	span.onclick = function() {
		modal.style.display = "none";
	}

	// When the user clicks anywhere outside of the modal, close it
	window.onclick = function(event) {
		if (event.target == modal) {
			modal.style.display = "none";
		}
	}
}

function update_data (key) {
	
	if(edit_title.value =="" || edit_kategori.value =="" || edit_perawi.value =="" || edit_teks.value ==""){
		alert("Data tidak boleh kosong!");
	}
	else{
		var database =  firebase.database();
		var updates = {};
		updates[key] = {
			title: edit_title.value,
			kategori: edit_kategori.value,
			perawi: edit_perawi.value,
			teks: edit_teks.value
		};
		//var result = database.ref().update(updates, err);
		var result = database.ref().update(updates, function(error) {
			if (error) {
				alert("Data could not be saved." + error);
			} else {
				alert("Data saved successfully.");
				location.reload();
			}
		});
	}
};

function deleteData (t) {
	if (confirm("Yakin ingin menghapus data ini?") == true) {
        firebase.database().ref().child(t).remove();
		location.reload();
    } else {
        console.log("doank");
    }
};



