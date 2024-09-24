function toggleMenuOpen() {
    return document.body.classList.toggle("open");
}




window.addEventListener('scroll', function () {
    var content = document.querySelector('.sobrenosmaior');
    var contentPosition = content.getBoundingClientRect().top;
    var screenPosition = window.innerHeight / 1.3;

    if (contentPosition < screenPosition) {
        content.classList.add('show');
    }

});



window.addEventListener('scroll', function () {
    var content = document.querySelector('.footer');
    var contentPosition = content.getBoundingClientRect().top;
    var screenPosition = window.innerHeight / 1.3;

    if (contentPosition < screenPosition) {
        content.classList.add('show');
    }
});
window.addEventListener('scroll', function () {
    var content = document.querySelector('.icon-default');
    var contentPosition = content.getBoundingClientRect().top;
    var screenPosition = window.innerHeight / 1.3;

    if (contentPosition < screenPosition) {
        content.classList.add('show');
    }
});
window.addEventListener('scroll', function () {
    var content = document.querySelector('.icon-default2');
    var contentPosition = content.getBoundingClientRect().top;
    var screenPosition = window.innerHeight / 1.3;

    if (contentPosition < screenPosition) {
        content.classList.add('show');
    }
});



window.addEventListener('scroll', function () {
    var content = document.querySelector('.avalia');
    var contentPosition = content.getBoundingClientRect().top;
    var screenPosition = window.innerHeight / 1.3;

    if (contentPosition < screenPosition) {
        content.classList.add('show');
    }
});

window.addEventListener('scroll', function () {
    var content = document.querySelector('.icon-default3');
    var contentPosition = content.getBoundingClientRect().top;
    var screenPosition = window.innerHeight / 1.3;

    if (contentPosition < screenPosition) {
        content.classList.add('show');
    }
});

window.addEventListener('scroll', function () {
    var content = document.querySelector('.funci');
    var contentPosition = content.getBoundingClientRect().top;
    var screenPosition = window.innerHeight / 1.3;

    if (contentPosition < screenPosition) {
        content.classList.add('show');
    }
});
