const buttonContainer = document.querySelector('.button-container');
let lastScrollPosition = window.pageYOffset;

window.addEventListener('scroll', () => {
    const currentScrollPosition = window.pageYOffset;
    if (currentScrollPosition < lastScrollPosition) {
        buttonContainer.style.opacity = '1';
    } else {
        buttonContainer.style.opacity = '0';
    }
    lastScrollPosition = currentScrollPosition;
});