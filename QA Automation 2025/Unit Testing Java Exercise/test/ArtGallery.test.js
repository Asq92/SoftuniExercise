import { artGallery } from "../05-exercise.js"
import { expect } from 'chai'
describe('artGallery', () => {
    describe('test addArtwork', () => {
        it('shoud throw error if title is not a string', () => {
            //Arrange
            let errorMessage = "Invalid Information!"

            //Act & Assert
            expect ( () => artGallery.addArtwork(42, '50 x 70', 'Picasso')).to.throw(errorMessage)
            expect ( () => artGallery.addArtwork([], '50 x 70', 'Picasso')).to.throw(errorMessage)
            expect ( () => artGallery.addArtwork({}, '50 x 70', 'Picasso')).to.throw(errorMessage)
            expect ( () => artGallery.addArtwork(null, '50 x 70', 'Picasso')).to.throw(errorMessage)
            
    })
    it('shoud throw error if artist is not a string', () => {
            //Arrange
            let errorMessage = "Invalid Information!"

            //Act & Assert
            expect ( () => artGallery.addArtwork('Dove of peace', '50 x 70', 5)).to.throw(errorMessage)
            expect ( () => artGallery.addArtwork('Dove of peace', '50 x 70', [])).to.throw(errorMessage)
            expect ( () => artGallery.addArtwork('Dove of peace', '50 x 70', {})).to.throw(errorMessage)
            expect ( () => artGallery.addArtwork('Dove of peace', '50 x 70', null)).to.throw(errorMessage)
            
    })
    it('shoud throw error if dimension is not in valid format', () => {
            //Arrange
            let errorMessage = "Invalid Dimensions!"

            //Act & Assert
            expect ( () => artGallery.addArtwork('Dove of peace', 42, 'Picasso')).to.throw(errorMessage)
            expect ( () => artGallery.addArtwork('Dove of peace', '30x40', 'Picasso')).to.throw(errorMessage)
            expect ( () => artGallery.addArtwork('Dove of peace', '75x 50', 'Picasso')).to.throw(errorMessage)
            expect ( () => artGallery.addArtwork('Dove of peace', '75 x50', 'Picasso')).to.throw(errorMessage)
         
            
    })
    it('shoud throw an error if artist is not alowed', () => {
        //Arrange
        let errorMessage = "This artist is not allowed in the gallery!"
        let invalidArtist = "V.D Maistora"

        //Act & Assert

        expect( () => artGallery.addArtwork('Dove of peace', '30 x 50', invalidArtist)).to.throw(errorMessage)

    })
    it('shoud return properr message if all parameters are valid', () => {
        //Arrange
        let message = `Artwork added successfully: 'Dove of peace' by Picasso with dimensions 50 x 70.`
         
        //Act & Assert

        expect(artGallery.addArtwork('Dove of peace', '50 x 70', 'Picasso')).to.equal(message)
    })
    

    })
    describe('test calculateCosts', () => {
        it('shoud thrown an error if any parameter are not valid', () => {
            //Arrange
            let errorMessage = "Invalid Information!"
            expect(() => artGallery.calculateCosts('5', 10, true)).to.throw(errorMessage)
            expect(() => artGallery.calculateCosts(5, '10', true)).to.throw(errorMessage)
            expect(() => artGallery.calculateCosts(5, 10, 'text')).to.throw(errorMessage)
            expect(() => artGallery.calculateCosts(-5, 10, true)).to.throw(errorMessage)
            expect(() => artGallery.calculateCosts(5, -10, true)).to.throw(errorMessage)
        })
        it('with sponsor => (true)', () => {
            let message = `Exhibition and insurance costs are 270$, reduced by 10% with the help of a donation from your sponsor.`;
            expect(artGallery.calculateCosts(100, 200, true)).to.equal(message)
        })
         it('without sponsor => (false)', () => {
            let message = `Exhibition and insurance costs are 300$.`;
            expect(artGallery.calculateCosts(100, 200, false)).to.equal(message)
        })
    })
    describe('test organizeExhibits', () => {
         it('shoud throw an error if input parameter is not valid', () => {
            // validate first parameter
            expect(() => artGallery.organizeExhibits('abc', 100)).to.throw("Invalid Information!")
            expect(() => artGallery.organizeExhibits(-10, 100)).to.throw("Invalid Information!")
            // validate second parameter
            expect(() => artGallery.organizeExhibits(10, 'abc')).to.throw("Invalid Information!")
            expect(() => artGallery.organizeExhibits(10, -10)).to.throw("Invalid Information!")
        }),
        it('shour return proper message if artworksPerSpace is less than 5', () => {
            let expected = `There are only 4 artworks in each display space, you can add more artworks.`
            expect(artGallery.organizeExhibits(100, 22)).to.equal(expected)
        }),
        it('shour return proper message if artworksPerSpace is greater than 5', () => {
            let expected = `You have 15 display spaces with 6 artworks in each space.`
            expect(artGallery.organizeExhibits(100, 15)).to.equal(expected)
        }),
         it('shour return proper message if artworksPerSpace is equal to 5', () => {
            let expected = `You have 18 display spaces with 5 artworks in each space.`
            expect(artGallery.organizeExhibits(100, 18)).to.equal(expected)
        })
    })
})