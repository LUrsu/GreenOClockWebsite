$(document).ready(function () {
    $.get(location.protocol + "//" + location.host + "/Progress/ActiveActivity", function (data) {
        if ($("#active-activity-display") != undefined) {
            $("#active-activity-display section").html(data);
            handleSlider();
        }

        var timer = $("#active-activity-display #timer")[0];
        if (timer != undefined) {
            handleOnLeavePage();
            handleTimer();
        }
    }, "html");
});

function handleSlider() {
	var showing = true;
	$("#toggle-activity-display").click(function () {
	    if (showing) {
	        $("#active-activity-display section").hide(0);
	        $("#toggle-activity-display").text("show");
	    } else {
	        $("#active-activity-display section").show(0);
	        $("#toggle-activity-display").text("hide");
	    }
	    showing = !showing;
	});
}

function handleOnLeavePage() {
	var leaving = true;

	$("a, input[type=submit], button.nav-internal").click(function () {
		leaving = false;
	});

	window.onbeforeunload = function () {
		if (!leaving)
			return undefined;
		return "You may have just tried to leave the site, but you still have an active activity. If you leave, we will try to save your progress but we can't make any promises...";
	};
}

function handleTimer() {
	var secondsElapsed = 0;

	function updateSeconds() {
		$.getJSON("/Progress/ActiveActivityTime", function (data) {
			secondsElapsed = data["seconds"];
		});
	}
	updateSeconds();
	setInterval(function () {
		updateSeconds();
	}, 60000);
	function updateDisplay() {
		var sec = secondsElapsed;
		var hour = Math.floor(sec / 3600);
		sec = sec % 3600;
		var min = Math.floor(sec / 60);
		sec = sec % 60;

		function pad(num) {
			return (num < 10 ? "0" : "") + num;
		}
		$("#timer").html(hour + ":" + pad(min) + ":" + pad(sec));
	}
	updateDisplay();
	setInterval(function () {
		secondsElapsed++;
		updateDisplay();
	}, 1000);
}
