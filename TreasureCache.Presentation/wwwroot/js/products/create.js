$(document).ready(() => {

    $('#uploadForm').on('submit', async (e) =>
    {
        e.preventDefault();
        const formData = new FormData(e.originalEvent.target);
        $.each(dropAreas, (_, config) =>
        {
            const { input, droppedFiles } = config;
            droppedFiles !== null && formData.set(input.attr('name'), droppedFiles[0]);
        });

        try
        {
            const response = await fetch('/Products/Create', {
                method: 'POST',
                body: formData
            });
            if (response.status === 422)
            {
                const errors = await response.json();
                clearAndDisplayValidationErrors(errors);
            }
            else if (response.status === 200)
            {
                const data = await response.json();
                window.location.href = data.url;
            }
        }
        catch (error)
        {
            console.error(error);
        }
    })

    const dropAreas = {
        '#small-image-drop-area': {
            previewArea: $('#small-image-preview-area'),
            imgAlt: 'Small image',
            input: $('#Request_SmallImage'),
            droppedFiles: null
        },
        '#large-image-drop-area': {
            previewArea: $('#large-image-preview-area'),
            imgAlt: 'Large image',
            input: $('#Request_LargeImage'),
            droppedFiles: null
        }
    };
    const clearAndDisplayValidationErrors = (errors) =>
    {
        $('[data-valmsg-for]').empty();
        $.each(errors, (key, values) =>
        {
            const fieldName = key[0].toUpperCase() + key.substring(1);
            const errorElement = $(`[data-valmsg-for="${fieldName}"]`);
            values.forEach((message) => errorElement.append(`${message}`) );
        });
    }

    const trashIconSVG = `<div class="absolute top-0 right-0">
                <svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-trash-off text-red-600" width="24" height="24" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor" fill="none" stroke-linecap="round" stroke-linejoin="round">
                    <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                    <path d="M3 3l18 18"/>
                    <path d="M4 7h3m4 0h9"/>
                    <path d="M10 11l0 6"/>
                    <path d="M14 14l0 3"/>
                    <path d="M5 7l1 12a2 2 0 0 0 2 2h8a2 2 0 0 0 2 -2l.077 -.923"/>
                    <path d="M18.384 14.373l.616 -7.373"/>
                    <path d="M9 5v-1a1 1 0 0 1 1 -1h4a1 1 0 0 1 1 1v3"/>
                </svg>
            </div>`;

    const imageElement = `<img class="w-full h-64 object-cover rounded-lg">`;

    $.each(dropAreas, (id, config) =>
    {
        const dropArea = $(id);
        const { input } = config;

        dropArea.on('dragover', (e) => {
            e.preventDefault(); // Prevent default behavior for both events
        });
        dropArea.on('drop', (e) => {
            e.preventDefault(); // Prevent default behavior for both events
            const files = Array.from(e.originalEvent.dataTransfer.files);
            clearFileUpload(config); // Clear before displaying new image

            config.droppedFiles = files;
            handleFileSelection(files[0], config);
        });
        input.on('change', (e) => {
            e.preventDefault()
            const files = Array.from(e.target.files);
            clearFileUpload(config);
            
            config.droppedFiles = files;
            handleFileSelection(files[0], config);
        });
    })
    const handleFileSelection = (file, config) => {
        if (!file) return;

        const { previewArea, imgAlt } = config;
        const image = $(imageElement).attr('alt', imgAlt);
        const trashIcon = $(trashIconSVG).on('click', () => clearFileUpload(config));

        displayImageFromFile(file, previewArea, image);
        previewArea.append(trashIcon);
        togglePreviewVisibility();
    };
    const togglePreviewVisibility = () => {
        const anyHasContent = Object.values(dropAreas).some(({ previewArea }) => previewArea.children().length > 0);

        $.each(dropAreas, (_, { previewArea }) => {
            if (anyHasContent) {
                previewArea.show(); // Show all if any has content
            } else {
                previewArea.hide(); // Hide all if none have content
            }
        });
    };
    const clearFileUpload = (config) =>
    {
        const {input, previewArea} = config;
        
        input.val('');
        previewArea.empty();
        config.droppedFiles = null;
        
        togglePreviewVisibility();
    }
    const displayImageFromFile = (file, parentElement, imageElement) =>
    {
        const reader = new FileReader();
        reader.onload = (event) => {
            imageElement.attr('src', event.target.result);
            parentElement.append(imageElement);
        };
        reader.readAsDataURL(file);
    }
});