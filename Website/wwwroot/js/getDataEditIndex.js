function SaveChange() {
    let inputText1 = document.getElementById("editIndexFieldTextInput1").value;
    let inputText2 = document.getElementById("editIndexFieldTextInput2").value;
    localStorage.setItem('input1', inputText1);
    localStorage.setItem('input2', inputText2);
    window.location.href = 'https://localhost:44346/site/index';
};