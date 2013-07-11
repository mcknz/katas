describe("App", function() {
    it("runs", function() {
      expect(2+2).toBe(4);
    });
});

describe("closestToZeroCalculator", function() {

	it("returnsOne_WhenArrayOfPositiveIntegers", function() {
		expect(closestToZeroCalculator([4,1,5,3])).toBe(1);
	});


	it("returnsNegativeTwo_WhenArrayOfNegativeIntegers", function() {
		expect(closestToZeroCalculator([-4,-2,-8,-9])).toBe(-2);
	});

	it("returnsNegativeTwo_WhenArrayOfMixedIntegers", function() {
		expect(closestToZeroCalculator([-2,3,4,-5])).toBe(-2);
	});

	it("returnsThree_WhenArrayOfMixedIntegers", function() {
		expect(closestToZeroCalculator([-9,3,4,-5])).toBe(3);
	});

	it("returnsTwo_WhenArrayOfEquivalentAbsIntegers", function() {
		expect(closestToZeroCalculator([2,-2,-4,6, -6, 7, -8, 9000])).toBe(2);
	});

	it("returnsTwo_WhenArrayOfEquivalentAbsIntegers", function() {
		expect(closestToZeroCalculator([-2,-4,6, -6, 7, -8, 9000, 2])).toBe(2);
	});

	it("returnsNull_WhenEmptyArrayPassed", function() {
		expect(closestToZeroCalculator([])).toBe(null);
	});

	it("returnsZero_WhenZeroPassed", function() {
		expect(closestToZeroCalculator([-0.00])).toBe(0.);
	});

});