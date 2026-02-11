import { analyzeArray } from '../04-exercise.js';
import { expect } from 'chai';

describe('test analyzeArray', () => {
    it('shoud return undefined if input parameter is not a array', () => {
        expect(analyzeArray(42)).to.be.undefined
        expect(analyzeArray('text')).to.be.undefined
        expect(analyzeArray({})).to.be.undefined
        expect(analyzeArray(null)).to.be.undefined
        expect(analyzeArray(undefined)).to.be.undefined

        expect(analyzeArray([])).to.be.undefined
    })
    it('if input is a single element array', () => {
    expect(analyzeArray([5]).min).to.equal(5)
    expect(analyzeArray([5]).max).to.equal(5)
    expect(analyzeArray([5]).length).to.equal(1)
    })
    it('if input is equal elements array', () => {
    //Arrange
    let array = [5, 5, 5, 5]

    //Act&Assert
    
    expect(analyzeArray(array).min).to.equal(5)
    expect(analyzeArray(array).max).to.equal(5)
    expect(analyzeArray(array).length).to.equal(4)
    })
    it('if input is a array with several numbers', () => {
        //Arrange
        let array = [-3, 5, 12, 42, 3]

        //Act & Assert
    expect(analyzeArray(array).min).to.equal(-3)
    expect(analyzeArray(array).max).to.equal(42)
    expect(analyzeArray(array).length).to.equal(5)
    })

})