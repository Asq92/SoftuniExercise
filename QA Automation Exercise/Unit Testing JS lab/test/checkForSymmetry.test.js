import {isSymmetric} from '../02-lab.js'
import {expect} from 'chai'

describe('Test function isSymmetric', () => {

    it ('should return false if imput is not array', () => {
    //Arrange
   
    let name = "test";
    
    //Act
    let result = isSymmetric(name);

    //Assert
    expect(result).to.be.false;

    }),

    it ('should return true if array is symmetric', () => {
    //Arrange
    let array = [1, 2, 2, 1];
    
    //Act
    let result = isSymmetric(array);

    //Assert

    expect(result).to.be.true;

    }),

    it ('should return false if array is notsymmetric', () => {
    //Arrange
    let array = [1, 2, 3, 4];
    
    //Act
    let result = isSymmetric(array);

    //Assert

    expect(result).to.be.false;
    
    }),

    it('should return true for empty array', () => {
        let array = [];
        let result = isSymmetric(array);
        expect(result).to.be.true;
    });

    it('should return true for symmetric array with mixed types', () => {
        let array = [1, "a", true, "a", 1];
        let result = isSymmetric(array);
        expect(result).to.be.true;
    }),
    
it('should return true for single-element array', () => {
    let array = [42];
    let result = isSymmetric(array);
    expect(result).to.be.true;
});


it('should return true for symmetric array with nested arrays', () => {
    let array = [[1,2], [3,4], [1,2]];
    let result = isSymmetric(array);
    expect(result).to.be.true;
});

});