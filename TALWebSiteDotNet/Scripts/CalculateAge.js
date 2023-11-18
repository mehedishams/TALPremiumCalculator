// From https://www.aspdotnet-suresh.com/2010/10/how-to-calculate-age-of-person-and.html
function CalculateAge(birthday) {
    var re=/^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d+$/;
    if (birthday.value != '') {
        if(re.test(birthday.value )) {
            birthdayDate = new Date(birthday.value);
            dateNow = new Date();

            var years = dateNow.getFullYear() - birthdayDate.getFullYear();
            var months=dateNow.getMonth()-birthdayDate.getMonth();
            var days=dateNow.getDate()-birthdayDate.getDate();
            if (isNaN(years)) {
                //document.getElementById('lblAge').innerHTML = '';
                //document.getElementById('lblError').innerHTML = 'Input date is incorrect!';
                return false;
            }
            else {
                //document.getElementById('lblError').innerHTML = '';
                if(months < 0 || (months == 0 && days < 0)) {
                    years = parseInt(years) - 1;
                    document.getElementById('txtAge').value = years
                }
                else {
                    document.getElementById('txtAge').value = years
                }
            }
        }
        else {
            //document.getElementById('lblError').innerHTML = 'Date must be mm/dd/yyyy format';
        return false;
        }
    }
}
