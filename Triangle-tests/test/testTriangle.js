const isRightTriangle = require("../triangle");
const assert = require("chai").assert;

describe("Testing isRightTriangle function", () => {
    it("return true with right args", () => {
        assert.equal(isRightTriangle(3, 4, 5), true);
    });
    it("return false when one of args = 0", () => {
        assert.isFalse(isRightTriangle(0, 4, 5));
    });
    it("return false when all args = 0", () => {
        assert.isFalse(isRightTriangle(0, 0, 0));
    });
    it("function returns boolean value", () => {
        assert.typeOf(isRightTriangle(3, 4, 5), "boolean");
    });
    it("function works with float values", () => {
        assert.isTrue(isRightTriangle(22.2, 44.1, 50.1));
    });
    it("function return false when one of args is negative", () => {
        assert.isFalse(isRightTriangle(-2, 3, 4));
    });
    it("return false when all args is negative", () => {
        assert.isFalse(isRightTriangle(-2, -3, -4));
    });
    it("function return false when a >= b+c || b >= a+c || c >= a+b", () => {
        assert.isFalse(isRightTriangle(10, 2, 3));
    });
    it("return false when function has not enought args", () => {
        assert.isFalse(isRightTriangle(2, 3));
    });
    it("return false when one of args has string value", () => {
        assert.isFalse(isRightTriangle("2", 3, 4));
    });
})