var isChromeBrowser = function () { // Actually, isWithChromePDFReader
	for (var i = 0; i < navigator.plugins.length; i++)
		if (navigator.plugins[i].name == 'Chrome PDF Viewer') return true;
	
	return false;
}

var chromiumEmbeddedHostname = "server";
var dummyWebServerHostname   = "192.168.2.101:8888";
var hostname = chromiumEmbeddedHostname;

if (isChromeBrowser())
	hostname = dummyWebServerHostname;        

var serverReq = function(oArgs) {
	console.log("request to " + oArgs.command + " with params " + JSON.stringify(oArgs.data));
	
	var success = function(data) {
		console.log("response to " + oArgs.command + " returns: ");
		console.log(data);
		if (oArgs.success)
			oArgs.success(data);
	};
	var error = function() {
		console.log("ERROR to " + oArgs.command);
		if (oArgs.error)
			oArgs.error();
	};
	
	$.ajax({
		url:      "http://" + hostname + oArgs.command,
		dataType: 'jsonp',
		data:     oArgs.data,
		cache:    false,
		success:  success,
		error:    error,
		});
};