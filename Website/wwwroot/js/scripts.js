document.getElementById('Name').oninput = function ()
{
    if (document.querySelector('input[name="Email"]').value != "" && document.querySelector('input[name="Message"]').value != "")
        document.getElementById('btnSendRequest').disabled = false;
}

document.getElementById('Email').oninput = function () {
    if (document.querySelector('input[name="Name"]').value != "" && document.querySelector('input[name="Message"]').value != "")
        document.getElementById('btnSendRequest').disabled = false;
}

document.getElementById('Message').oninput = function () {
    if (document.querySelector('input[name="Name"]').value != "" && document.querySelector('input[name="Email"]').value != "")
        document.getElementById('btnSendRequest').disabled = false;
}