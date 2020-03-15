const container = document.querySelector('.PAnDa');
const keys = document.querySelectorAll('.key');
const panda = document.querySelector('.panda');
const eyes = document.querySelectorAll('.eye');
const features = document.querySelectorAll('.feature');
const leftear = document.querySelector('.leftear');
const rightear = document.querySelector('.rightear');
const mouth = document.querySelector('.mouth');

const synth = new Tone.Synth();
const gain = new Tone.Gain(0.5);
gain.toMaster();
synth.connect(gain);

const calcValue = (mouse, width) => {
    return (mouse / width * limit - limit / 2).toFixed(1);
};

const setContainerSize = () => {
    let size = window.innerHeight / 2.76;
    if (size > window.innerWidth) {
        size = window.innerWidth / 2.76;
    }
    container.style.height = `350px`;
    container.style.width = `350px`;
};

setContainerSize();

[...keys].forEach(key => {
    key.addEventListener('mouseover', () => sing(key.dataset.note));
    key.addEventListener('click', () => sing(key.dataset.note));
});

let singTimeout;
const sing = note => {
    if (singTimeout) clearTimeout(singTimeout);

    synth.triggerAttackRelease(note, '12n');

    mouth.setAttribute('ry', '10');

    singTimeout = setTimeout(() => {
        mouth.setAttribute('ry', '3');
    }, 300);
};

let resizeTimeout;
window.addEventListener('resize', () => {
    if (resizeTimeout) window.cancelAnimationFrame(resizeTimeout);
    resizeTimeout = window.requestAnimationFrame(() => {
        setContainerSize();
    });
}, false);

const limit = 15;
let timeout;
window.addEventListener('mousemove', event => {
    if (timeout) window.cancelAnimationFrame(timeout);

    panda.classList.remove('idle');

    timeout = window.requestAnimationFrame(() => {
        let xValue = calcValue(event.x, window.innerWidth);
        let yValue = calcValue(event.y, window.innerHeight);

        [...features].forEach(feature => {
            feature.style.transform = `translateX(${xValue}px) translateY(${yValue}px)`;
        });

        [...eyes].forEach(eye => {
            eye.setAttribute('ry', '7.5');
            eye.style.transform = `translateX(${xValue * 2}px) translateY(${yValue * 2.5 }px)`;
        });

        leftear.style.transform = `translateX(${-xValue * 0.7}px) translateY(${-yValue * 0.7}px)`;
        rightear.style.transform = `translateX(${-xValue * 0.7}px) translateY(${-yValue * 0.7}px)`;
    });
}, false);

