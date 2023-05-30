let input1 = localStorage.getItem('input1');
let input2 = localStorage.getItem('input2');
if (input1 != null) {
    document.getElementById('indexFieldText1').innerHTML = input1;
}

if (input2 != null) {
    document.getElementById('indexFieldText2').innerHTML = input2;
}