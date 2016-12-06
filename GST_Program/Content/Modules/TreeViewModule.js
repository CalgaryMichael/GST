﻿var $treeCanvas = $('#treeCanvas');

$treeCanvas.drawImage({
    source: '../../Content/TreeImages/Tree/tree.jpg',
    layer: true,
    groups: ['tree'],
    fromCenter: false,
    Index: 0
});

$treeCanvas.drawImage({
    source: '../../Content/TreeImages/Badge/apple.png',
    layer: true,
    name: 'apple',
    x: 440, y: 355,
    scale: 0.015
});
$treeCanvas.addLayerToGroup('apple', 'tree');