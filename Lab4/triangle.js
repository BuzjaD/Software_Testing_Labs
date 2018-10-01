module.exports = (a, b, c) => (
    typeof a === "number" && typeof b === "number" && typeof c === "number" ?
    (a <= 0 || b <= 0 || c <= 0 || a >= b + c || b >= c + a || c >= a + b ?
        false :
        true) :
    false
);