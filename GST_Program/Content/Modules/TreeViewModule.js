var $treeCanvas = $('#treeCanvas');

$treeCanvas.addLayer({
    type: 'image',
    source: '../../Content/TreeImages/Tree/tree.jpg',
    fromCenter: false
})
.addLayer({
    type: 'image',
    source: '../../Content/TreeImages/Badge/apple.png',
    x: 440, y: 355,
    scale: 0.015
})
.drawLayers();