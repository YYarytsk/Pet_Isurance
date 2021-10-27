// const btn = document.querySelector('button')
// const inputs = document.querySelector('form')

// btn.addEventListener('click', () => {
//     Email.send({
//         Host: "smtp.mailtrap.io",
//         Username: "fac2d613347d9e",
//         Password: "9c7d4b62a575a1",
//         To: "yyarytskyy@yahoo.com",
//         From: inputs.elements["email"].value,
//         Subject: inputs.elements["subject"].value,
//         Body: inputs.elements["message"].value + "<br>" + inputs.elements["name"].value
//     }).then(msg=>alert("Email sent successfully!"))
// })

function sendMail(){
    var tempParams ={
        subject:document.getElementById(subject).value,
        from_name:document.getElementById(fromName).value,
        message:document.getElementById(message).value,
        email:document.getElementById(email).value
    };
    emailjs.send('service_v2bvq0h', 'template_d8hoiul', tempParams).then(function(res){
        console.log("success", res.status);
    })
}