window.addEventListener('load', () => {
  document.querySelector('main').classList.remove('obscured');
});

const showModal = name => {
  document.getElementById(`${name}-modal`).classList.remove('obscured');
}
const hideModal = name => {
  document.getElementById(`${name}-modal`).classList.add('obscured');
}