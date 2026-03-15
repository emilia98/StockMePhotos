$(document).ready(() => {
    const previewImage = $('div.preview-img')[0];
    const inputImage = $('input#Image');

    inputImage.on('change', (e) => {
        const file = $(e.target)[0].files[0];

        if (file.type.startsWith("image/")) {
            const imageUrl = URL.createObjectURL(file);
            $(previewImage).css('background-image', `url(${imageUrl})`);
        }
        else {
            $(previewImage).css('background-image', "none");
        }
    });
});