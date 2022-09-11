// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

if ("webkitSpeechRecognition" in window) {
    // Initialized webkitSpeechRecognition
    let speechRecognition = new webkitSpeechRecognition();

    var error = false;

    // Configurations
    speechRecognition.continuous = false;
    speechRecognition.interimResults = true;

    // On Start of Recognition
    speechRecognition.onstart = () => {
        document.querySelector("#status").innerHTML = "Listening...";
        document.querySelector("#start_img").style.display = "none";
        document.querySelector("#stop_img").style.display = "inline";
        document.querySelector("#text-input").value = "";
        document.querySelector("#start").value = "true";
        console.log(document.querySelector("#select_language").value);
        error = false;
    };

    // On End of Recognition
    speechRecognition.onend = () => {
        if (error) {
            document.querySelector("#status").innerHTML = "Your microphone is not working or microphone access is blocked.";
        }
        else {
        document.querySelector("#status").innerHTML = "";
        }
        document.querySelector("#stop_img").style.display = "none";
        document.querySelector("#start_img").style.display = "inline";
        document.querySelector("#start").value = "false";
    };

    // On Error
    speechRecognition.onerror = () => {
        error = true;
        console.log("error");
    };

    // While speech is processed
    speechRecognition.onresult = (event) => {

        let interim_transcript = "";
        let final_transcript = "";

        // Loop through the results from the speech recognition object.
        for (let i = event.resultIndex; i < event.results.length; ++i) {

            // If the result item is Final, add it to Final Transcript, Else add it to Interim transcript
            if (event.results[i].isFinal) {
                final_transcript += event.results[i][0].transcript;
                document.querySelector("#text-input").value = final_transcript;
                submitButton();
            } else {
                interim_transcript += event.results[i][0].transcript;
                document.querySelector("#text-input").value = interim_transcript;
            }
        }
    };

    // Toggle function for the Button
    function buttonToggle() {
        var isListening = document.querySelector("#start").value;
        var selected_lang = document.querySelector("#select_language").value;

        if (selected_lang == "select-SL")
        {
            return;
        }

        if (isListening === "false") {
            console.log("started listening");
            speechRecognition.lang = selected_lang;
            speechRecognition.start();
        }

        else if (isListening === "true") {
            console.log("stopped listening");
            speechRecognition.stop();
        }
    }


    speechRecognition.onspeechstart = () => {
        console.log("speech detected");
    }

    speechRecognition.onspeechend = () => {
        console.log("ended by onspeechend");
        speechRecognition.stop();
    }

} else {
    document.querySelector("#start_img").style.display = "none";
    document.querySelector("#status").innerHTML = "Speech Recognition Not Available on This Browser | Use Google Chrome";
}

function submitButton() {
    document.querySelector("form").submit();
}

// trigger submitButton on user type

function delay(fn, ms) {
    let timer = 0
    return function (...args) {
        clearTimeout(timer)
        timer = setTimeout(fn.bind(this, ...args), ms || 0)
    }
}

document.querySelector("#text-input").addEventListener("keyup", delay((e) => {
    submitButton();
}, 1200));